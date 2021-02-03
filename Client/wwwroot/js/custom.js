function scrollMessages() {
    //TODO: make this less horrible
    var allMessages = document.getElementsByClassName('own-message');
    
    if(allMessages.length == 0) {
        return;
    }

    var lastIndex = allMessages.length - 1;
    var lastElement = allMessages.item(lastIndex);
    lastElement.scrollIntoView();

}