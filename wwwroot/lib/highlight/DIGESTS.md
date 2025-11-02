## Subresource Integrity

If you are loading Highlight.js via CDN you may wish to use [Subresource Integrity](https://developer.mozilla.org/en-US/docs/Web/Security/Subresource_Integrity) to guarantee that you are using a legimitate build of the library.

To do this you simply need to add the `integrity` attribute for each JavaScript file you download via CDN. These digests are used by the browser to confirm the files downloaded have not been modified.

```html
<script
  src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/highlight.min.js"
  integrity="sha384-5xdYoZ0Lt6Jw8GFfRP91J0jaOVUq7DGI1J5wIyNi0D+eHVdfUwHR4gW6kPsw489E"></script>
<!-- including any other grammars you might need to load -->
<script
  src="//cdnjs.cloudflare.com/ajax/libs/highlight.js/11.11.1/languages/go.min.js"
  integrity="sha384-HdearVH8cyfzwBIQOjL/6dSEmZxQ5rJRezN7spps8E7iu+R6utS8c2ab0AgBNFfH"></script>
```

The full list of digests for every file can be found below.

### Digests

```
sha384-g7t9fKR5Tvod4iWv7BQXN+/JMn5GT9sD6FG3h7Fgl+KCv5k4NnnCzEqUe7BMJ9Mv /es/languages/javascript.js
sha384-f7huPivS1dV2T5V+g0aJpgsY7WBHWCsioIq30tpNoXGizD65fWJYGuXXVPNI52VB /es/languages/javascript.min.js
sha384-8CRS96Xb/ZkZlQU+5ffA03XTN6/xY40QAnsXKB0Y+ow1vza1LAkRNPSrZqGSNo53 /es/languages/json.js
sha384-UHzaYxI/rAo84TEK3WlG15gVfPk49XKax76Ccn9qPWYbUxePCEHxjGkV+xp9HcS/ /es/languages/json.min.js
sha384-i6sPjmXfHWLljAXTYYk0vBOwgsUnUKnKXKH41qzc9OMhaf5AFZqXH7azX4SYdUiR /es/languages/plaintext.js
sha384-OOrQLW97d+/1orj9gjftwbbQyV8LNAcgagqVKBhUYA08Hdi5w0p6VoB3yt2k7gnG /es/languages/plaintext.min.js
sha384-kSThHXIGsuTwuXE64czf2UR1eqvnzlZi1lD/rh68GxoMCP6TOyJjOX0qFcV0NTui /es/languages/vala.js
sha384-OIeJ9bZoeT3bq6Fr0UsjyDwbFT/ur4Ng3gAvTRBPP+WlWroaR5y1DkRVvy0DrDp0 /es/languages/vala.min.js
sha384-yxv7Fv9ToggiLsR67t98hV5ZRup6XX6xL1Rkbi/cGV5J8y7fosCi9POqlBkiBWFg /languages/javascript.js
sha384-tPOrIubtDHoQU7Rqw0o88ilthGO0/4xEZGB47XrQKWhrc1/SchwsDx+AP74u4nk0 /languages/javascript.min.js
sha384-pUlqdjoNePvHvdi7GVKJJnh/P2T3EvXXodl5j0JtTkbNC4DRH7gwGbcHFa84bFOP /languages/json.js
sha384-3C+cPClJZgjKFYAb0bh35D7im2jasLzgk9eRix3t1c5pk1+x6b+bHghWcdrKwIo3 /languages/json.min.js
sha384-MZKv9uidO1+VnHz8xWxPv6ACuLO5t823eanvTcKYnmi/ocdVYD8zKZNTxmF0nKEM /languages/plaintext.js
sha384-Z9EdtPaC8UiXHEq1WuQTdvqT+FwjLwaVTIwTCZW/dGfiU9nbF8Shvltrhqtw83Qb /languages/plaintext.min.js
sha384-uRDe6nvMbMejGKUv6ZuscDpAUEs68HxmudfcWK+1CS2xg17v2Kx4g6x6L8RqiV7A /languages/vala.js
sha384-k9lKwR136qS4QirtT8X0VU9MsU3/fnrticZ2xGFiUzbMifXfQJp58b4CMzBRIMEv /languages/vala.min.js
sha384-hpukAJTX3eDf6jzpto4Sds3rf3pCVzyqyqivAf5e3KJSEf3WEMsXgHwmH+71L70D /highlight.js
sha384-M72GuP8byIs+mRR4twNyHiHxxkpaTjVXqgBYIpnFg9b7HzOaMvjUXtyGr4uDKbCG /highlight.min.js
```

