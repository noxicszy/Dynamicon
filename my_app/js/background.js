// use this js to set background, including image or video, and whether it ripples

var background;
var mode = "video";
var ifRipple = true;

if(mode=="image"){
    background = document.createElement("img");
    background.id = "background";
    background.src = "./images/background.png";
}
else if(mode=="video"){
    background = document.createElement("video");
    background.id = "background";
    background.src = "videos/background2.mp4";
    background.autoplay = "autoplay"
    background.loop = "loop";
}
document.body.appendChild(background);


$(document).ready(function () {
    if(!ifRipple) return;
    try {
        $('body').ripples({
            resolution: 512,
            dropRadius: 10, //px
            perturbance: 0.02,
        });
    }
    catch (e) {
        $('.error').show().text(e);
    }

    // Automatic drops
    setInterval(function () {
        var $el = $('body');
        var x = Math.random() * $el.outerWidth();
        var y = Math.random() * $el.outerHeight();
        var dropRadius = 10;
        var strength = 0.02 + Math.random() * 0.02;

        $el.ripples('drop', x, y, dropRadius, strength);
    }, 800);
});