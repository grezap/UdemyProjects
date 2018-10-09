tinymce.init({ selector: 'textarea' });

(function(){
    var msgLabel = $('#msg');
    if(msgLabel){
        msgLabel.delay(6000).slideUp(300);
    }
})();

