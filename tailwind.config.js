const plugin = require('tailwindcss/plugin');

/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './**/*.{razor,html,cshtml}',
        './wwwroot/**/*.js',
    ],
    plugins: [
        require('@tailwindcss/forms'),
        require('@tailwindcss/aspect-ratio'),
        require('@tailwindcss/typography'),
        plugin(function ({ addComponents }) {
            addComponents({
                'code': {
                    '@apply bg-gray-200/40 !important': '',
                    '@apply dark:bg-gray-900 !important': '',
                }
            })
        })
    ],
}
