function showElement(containerId, defaultPlayerUrl) {
    $('.modulesContent').hide();
    
    // reset playing videos
    $(".videoPlayerFrame:not(#videoPlayer_" + containerId + ")").attr("src", "");
    // set new video to play
    $("#videoPlayer_" + containerId).attr("src", defaultPlayerUrl);
    
    $("#" + containerId).show();
}

function showVideo(mediaUrl, frameId) {
    $("#" + frameId).attr("src", mediaUrl);
}