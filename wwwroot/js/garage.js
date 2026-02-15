function showAddVehicleModal() {
    uploadedFile = "";
    $.get('/Vehicle/AddVehiclePartialView', function (data) {
        if (data) {
            $("#addVehicleModalContent").html(data);
            initTagSelector($("#inputTag"));
            initDatePicker($('#inputPurchaseDate'));
            initDatePicker($('#inputSoldDate'));
            $('#addVehicleModal').modal('show');
        }
    })
}
function hideAddVehicleModal() {
    $('#addVehicleModal').modal('hide');
}
//refreshable function to reload Garage PartialView
function loadGarage() {
    $.get('/Home/Garage', function (data) {
        $("#garageContainer").html(data);
        bindTabEvent();
    });
}
function getVehicleSupplyRecords() {
    $.get(`/Vehicle/GetSupplyRecordsByVehicleId?vehicleId=0`, function (data) {
        if (data) {
            $("#supply-tab-pane").html(data);
            restoreScrollPosition();
        }
    });
}
function GetVehicleId() {
    return { vehicleId: 0, hasOdometerAdjustment: false };
}
function bindTabEvent() {
    $('button[data-bs-toggle="tab"]').on('show.bs.tab', function (e) {
        switch (e.target.id) {
            case "supply-tab":
                getVehicleSupplyRecords();
                break;
            case "calendar-tab":
                getVehicleCalendarEvents();
                break;
        }
        switch (e.relatedTarget.id) { //clear out previous tabs with grids in them to help with performance
            case "supply-tab":
                $("#supply-tab-pane").html("");
                break;
            case "calendar-tab":
                $("#calendar-tab-pane").html("");
                break;
        }
        $(`.lubelogger-tab #${e.target.id}`).addClass('active');
        $(`.lubelogger-mobile-nav #${e.target.id}`).addClass('active');
        $(`.lubelogger-tab #${e.relatedTarget.id}`).removeClass('active');
        $(`.lubelogger-mobile-nav #${e.relatedTarget.id}`).removeClass('active');
    });
}
function getVehicleCalendarEvents() {
    $.get('/Home/Calendar', function (data) {
        if (data) {
            $("#calendar-tab-pane").html(data);
        }
    });
}
function showCalendarReminderDialog(id) {
    event.stopPropagation();
    $.get(`/Calendar/ViewCalendarReminder?reminderId=${id}`, function (data) {
        if (data) {
            $("#reminder-record-dialog").html(data);
            $("#reminder-record-dialog")[0].showModal();
            $('#reminder-record-dialog').off('shown.bs.modal').on('shown.bs.modal', function () {
                if (getGlobalConfig().useMarkDown) {
                    toggleMarkDownOverlay("reminder-notes");
                }
            });
        }
    })
}
function hideCalendarReminderDialog() {
    $("#reminder-record-dialog")[0].close();
}
function generateReminderItem(id, urgency, description) {
    if (description.trim() == '') {
        return;
    }
    switch (urgency) {
        case "VeryUrgent":
            return `<p class="badge text-wrap bg-danger reminder-calendar-item mb-2" onclick='showCalendarReminderModal(${id})'>${encodeHTMLInput(description)}</p>`;
        case "PastDue":
            return `<p class="badge text-wrap bg-secondary reminder-calendar-item mb-2" onclick='showCalendarReminderModal(${id})'>${encodeHTMLInput(description)}</p>`;
        case "Urgent":
            return `<p class="badge text-wrap text-bg-warning reminder-calendar-item mb-2" onclick='showCalendarReminderModal(${id})'>${encodeHTMLInput(description)}</p>`;
        case "NotUrgent":
            return `<p class="badge text-wrap bg-success reminder-calendar-item mb-2" onclick='showCalendarReminderModal(${id})'>${encodeHTMLInput(description)}</p>`;
    }
}
function markDoneCalendarReminderRecord(reminderRecordId, e) {
    event.stopPropagation();
    $.post(`/Vehicle/PushbackRecurringReminderRecord?reminderRecordId=${reminderRecordId}`, function (data) {
        if (data) {
            hideCalendarReminderDialog();
            successToast("Reminder Updated");
            getVehicleCalendarEvents();
        } else {
            errorToast(genericErrorMessage());
        }
    });
}
function deleteCalendarReminderRecord(reminderRecordId, e) {
    if (e != undefined) {
        event.stopPropagation();
    }
    
    hideCalendarReminderDialog();
    Swal.fire({
        title: "Confirm Deletion?",
        text: "Deleted Reminders cannot be restored.",
        showCancelButton: true,
        confirmButtonText: "Delete",
        confirmButtonColor: "#dc3545"
    }).then((result) => {
        if (result.isConfirmed) {
            $.post(`/Vehicle/DeleteReminderRecordById?reminderRecordId=${reminderRecordId}`, function (data) {
                if (data) {
                    successToast("Reminder Deleted");
                    selectDate(selectedDate, selectedDate.getFullYear(), selectedDate.getMonth() + 1);
                } else {
                    errorToast(genericErrorMessage());
                }
            });
        } else {
            $("#workAroundInput").hide();
        }
    });
}
function initCalendar() {
    if (groupedDates.length == 0) {
        //group dates
        eventDates.map(x => {
            var existingIndex = groupedDates.findIndex(y => y.date == x.date);
            if (existingIndex == -1) {
                groupedDates.push({ date: x.date, reminders: [`${generateReminderItem(x.id, x.urgency, x.description)}`] });
            } else if (existingIndex > -1) {
                groupedDates[existingIndex].reminders.push(`${generateReminderItem(x.id, x.urgency, x.description)}`);
            }
        });
    }
    $(".reminderCalendarViewContent").datepicker({
        startDate: "+0d",
        format: getShortDatePattern().pattern,
        todayHighlight: true,
        weekStart: getGlobalConfig().firstDayOfWeek,
        beforeShowDay: function (date) {
            var reminderDateIndex = groupedDates.findIndex(x => (x.date == date.getTime() || x.date == (date.getTime() - date.getTimezoneOffset() * 60000))); //take into account server timezone offset
            if (reminderDateIndex > -1) {
                return {
                    enabled: true,
                    classes: 'reminder-exist',
                    content: `<div class='text-wrap' style='height:20px;'><p>${date.getDate()}</p>${groupedDates[reminderDateIndex].reminders.join('<br>')}</div>`
                }
            }
        }
    });
}
function performLogOut() {
    $.post('/Login/LogOut', function (data) {
        if (data) {
            window.location.href = data;
        }
    })
}

function filterGarage(sender) {
    var rowData = $(".garage-item");
    if (sender == undefined) {
        rowData.removeClass('override-hide');
        return;
    }
    var tagName = sender.textContent;
    if ($(sender).hasClass("bg-blue-50")) {
        rowData.removeClass('override-hide');
        
        $(sender).removeClass('bg-blue-50');
        $(sender).removeClass('dark:bg-blue-900/20');
        $(sender).removeClass('text-blue-700');
        $(sender).removeClass('dark:text-blue-400');
        $(sender).removeClass('border');
        $(sender).removeClass('border-blue-700/10');
        $(sender).removeClass('dark:border-blue-400/30');
        $(sender).addClass('m-[1px]');
        $(sender).addClass('bg-gray-100');
        $(sender).addClass('dark:bg-gray-800');
        $(sender).addClass('text-gray-600');
        $(sender).addClass('dark:text-gray-300');
    } else {
        //hide table rows.
        rowData.addClass('override-hide');
        $(`[data-tags~='${tagName}']`).removeClass('override-hide');
        if ($(".tagfilter.bg-blue-50").length > 0) {
            //disabling other filters
            $(".tagfilter.bg-blue-50").addClass('m-[1px]');
            $(".tagfilter.bg-blue-50").addClass('bg-gray-100');
            $(".tagfilter.bg-blue-50").addClass('dark:bg-gray-800');
            $(".tagfilter.bg-blue-50").addClass('text-gray-600');
            $(".tagfilter.bg-blue-50").addClass('dark:text-gray-300');
            $(".tagfilter.bg-blue-50").removeClass('dark:bg-blue-900/20');
            $(".tagfilter.bg-blue-50").removeClass('text-blue-700');
            $(".tagfilter.bg-blue-50").removeClass('dark:text-blue-400');
            $(".tagfilter.bg-blue-50").removeClass('border');
            $(".tagfilter.bg-blue-50").removeClass('border-blue-700/10');
            $(".tagfilter.bg-blue-50").removeClass('dark:border-blue-400/30');
            $(".tagfilter.bg-blue-50").removeClass('bg-blue-50');
        }
        $(sender).addClass('bg-blue-50');
        $(sender).addClass('dark:bg-blue-900/20');
        $(sender).addClass('text-blue-700');
        $(sender).addClass('dark:text-blue-400');
        $(sender).addClass('border');
        $(sender).addClass('border-blue-700/10');
        $(sender).addClass('dark:border-blue-400/30');
        $(sender).removeClass('m-[1px]');
        $(sender).removeClass('bg-gray-100');
        $(sender).removeClass('dark:bg-gray-800');
        $(sender).removeClass('text-gray-600');
        $(sender).removeClass('dark:text-gray-300');
    }
}

// function manageCollaborators(vehicleId) {
//     if (event != undefined) {
//         event.stopPropagation();
//     }
//    
//     $.post('/Vehicle/GetVehiclesCollaborators', { vehicleIds: [vehicleId] }, function (data) {
//         if (isOperationResponse(data)) {
//             return;
//         } else if (data) {
//             $("#userCollaboratorsModalContent").html(data);
//             $("#userCollaboratorsModal").modal('show');
//         }
//     })
// }

function deleteVehicle(vehicleId) {
    if (event != undefined) {
        event.stopPropagation();
    }
    
    Swal.fire({
        title: "Confirm Deletion?",
        text: "This will also delete all data tied to this vehicle. Deleted Vehicles and their associated data cannot be restored.",
        showCancelButton: true,
        confirmButtonText: "Delete",
        confirmButtonColor: "#dc3545"
    }).then((result) => {
        if (result.isConfirmed) {
            $.post('/Vehicle/DeleteVehicle', { vehicleId: vehicleId }, function (data) {
                if (data) {
                    window.location.href = '/Home';
                }
            })
        }
    });
}

async function showVehicleExtraFields(vehicleId) {
    if (event != undefined) {
        event.stopPropagation();
    }
    
    Swal.fire({
        title: 'Vehicle Extra Fields',
        html: await $.get("/Home/GetVehicleExtraFieldsPartialView", { vehicleId: vehicleId }, function (data) { return data; }),
        confirmButtonText: 'Close',
        focusConfirm: false
    });
}

function sortVehicles(desc) {
    //get row data
    const rowData = $('.garage-item');
    const sortedRow = rowData.toArray().sort((a, b) => {
        const currentVal = globalParseFloat($(a).find(".garage-item-year").text());
        const nextVal = globalParseFloat($(b).find(".garage-item-year").text());
        if (desc) {
            return nextVal - currentVal;
        } else {
            return currentVal - nextVal;
        }
    });
    
    $('.vehiclesContainer').html(sortedRow);
}

function sortGarage() {
    if (event != undefined) {
        event.stopPropagation();
    }
    
    const defaultSortIcon = $(".default-sort");
    const sortAscIcon = $(".sort-asc");
    const sortDescIcon = $(".sort-desc");
    if (!sortAscIcon.hasClass("hidden")) {
        sortAscIcon.toArray().forEach(f => f.classList.add("hidden"));
        sortDescIcon.toArray().forEach(f => f.classList.remove("hidden"));
        sortVehicles(true);
    } else if (!sortDescIcon.hasClass("hidden")) {
        sortDescIcon.toArray().forEach(f => f.classList.add("hidden"));
        defaultSortIcon.toArray().forEach(f => f.classList.remove("hidden"));
        resetSortGarage();
    } else {
        //first time sorting.
        defaultSortIcon.toArray().forEach(f => f.classList.add("hidden"));
        sortAscIcon.toArray().forEach(f => f.classList.remove("hidden"));
        sortVehicles(false);
    }
}
function resetSortGarage() {
    const rowData = $(`.garage-item`);
    const sortedRow = rowData.toArray().sort((a, b) => {
        const currentVal = $(a).attr('id').split('_')[1];
        const nextVal = $(b).attr('id').split('_')[1];
        return currentVal - nextVal;
    });
    
    $(`.vehiclesContainer`).html(sortedRow);
}

let dragged = null;
let draggedId = 0;
function dragEnter(event) {
    event.preventDefault();
}
function dragStart(event, vehicleId) {
    dragged = event.target;
    draggedId = vehicleId;
    event.dataTransfer.setData('text/plain', draggedId);
}
function dragOver(event) {
    event.preventDefault();
}
function dropBox(event, targetVehicleId) {
    if (dragged.parentElement !== event.target && event.target !== dragged && draggedId !== targetVehicleId) {
        copyContributors(draggedId, targetVehicleId);
    }
    event.preventDefault();
}
function copyContributors(sourceVehicleId, destVehicleId) {
    var sourceVehicleName = $(`#gridVehicle_${sourceVehicleId} .card-body`).children('h5').map((index, elem) => { return elem.innerText }).toArray().join(" ");
    var destVehicleName = $(`#gridVehicle_${destVehicleId} .card-body`).children('h5').map((index, elem) => { return elem.innerText }).toArray().join(" ");
    Swal.fire({
        title: "Copy Collaborators?",
        text: `Copy collaborators over from ${sourceVehicleName} to ${destVehicleName}?`,
        showCancelButton: true,
        confirmButtonText: "Copy",
        confirmButtonColor: "#0d6efd"
    }).then((result) => {
        if (result.isConfirmed) {
            $.post('/Vehicle/DuplicateVehicleCollaborators', { sourceVehicleId: sourceVehicleId, destVehicleId: destVehicleId }, function (data) {
                if (data.success) {
                    successToast("Collaborators Copied");
                    loadGarage();
                } else {
                    errorToast(data.message);
                }
            })
        } else {
            $("#workAroundInput").hide();
        }
    });
}

function showAccountInformationModal() {
    $.get('/Home/GetUserAccountInformationModal', function (data) {
        $('#accountInformationDialogContent').html(data);
        $('#accountInformationDialog')[0].showModal();
    })
}

function showRootAccountInformationModal() {
    $.get('/Home/GetRootAccountInformationModal', function (data) {
        $('#accountInformationDialogContent').html(data);
        $('#accountInformationDialog')[0].showModal();
    })
}
function validateAndSaveRootUserAccount() {
    var hasError = false;
    if ($('#inputUsername').val().trim() == '') {
        $('#inputUsername').addClass("is-invalid");
        hasError = true;
    } else {
        $('#inputUsername').removeClass("is-invalid");
    }
    if ($('#inputPassword').val().trim() == '') {
        $('#inputPassword').addClass("is-invalid");
        hasError = true;
    } else {
        $('#inputPassword').removeClass("is-invalid");
    }
    if (hasError) {
        errorToast("Please check the form data");
        return;
    }
    var userAccountInfo = {
        userName: $('#inputUsername').val(),
        password: $('#inputPassword').val()
    }
    $.post('/Login/CreateLoginCreds', { credentials: userAccountInfo }, function (data) {
        if (data) {
            //hide modal
            hideAccountInformationModal();
            successToast('Root Account Updated');
            performLogOut();
        } else {
            errorToast(data.message);
        }
    });
}

function hideAccountInformationModal() {
    $('#accountInformationDialog')[0].close();
}
function validateAndSaveUserAccount() {
    var hasError = false;
    if ($('#inputUsername').val().trim() == '') {
        $('#inputUsername').addClass("is-invalid");
        hasError = true;
    } else {
        $('#inputUsername').removeClass("is-invalid");
    }
    if ($('#inputEmail').val().trim() == '') {
        $('#inputEmail').addClass("is-invalid");
        hasError = true;
    } else {
        $('#inputEmail').removeClass("is-invalid");
    }
    if ($('#inputToken').val().trim() == '') {
        $('#inputToken').addClass("is-invalid");
        hasError = true;
    } else {
        $('#inputToken').removeClass("is-invalid");
    }
    if (hasError) {
        errorToast("Please check the form data");
        return;
    }
    var userAccountInfo = {
        userName: $('#inputUsername').val(),
        password: $('#inputPassword').val(),
        emailAddress: $('#inputEmail').val(),
        token: $('#inputToken').val()
    }
    $.post('/Home/UpdateUserAccount', { userAccount: userAccountInfo }, function (data) {
        if (data.success) {
            //hide modal
            hideAccountInformationModal();
            successToast('Profile Updated');
            performLogOut();
        } else {
            errorToast(data.message);
        }
    });
}
function generateTokenForUser() {
    $.post('/Home/GenerateTokenForUser', function (data) {
        if (data) {
            successToast('Token sent');
        } else {
            errorToast(genericErrorMessage())
        }
    });
}

// function isOperationResponse(result) {
//     //checks if response from controller is operationresponse
//     if (result.success != undefined && result.message != undefined) {
//         if (!result.success) {
//             errorToast(result.message);
//         }
//         return true;
//     }
// }