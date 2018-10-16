$(document).ready(function(){
    $('#create-task').submit(function(event) {
        event.preventDefault();
        var form = $(this);
        var formData = form.serialize();
        $('#name_error').html("");
        $('#description_error').html("");
        $.ajax({
            url: 'create.php', 
            method: 'POST',
            data: formData,
            dataType: 'json',
            encode: true,
            success: function(data){
                if (data.success === false) {
                    if (data.message.name !== "") {
                        $('#name_error').css("display","block").html(data.message.name);
                    }
                    if (data.message.description !== "") {
                        $('#description_error').css("display","block").html(data.message.description);
                    }
                }else{
                    $('#ajax_msg').css('display','block').delay(3000).slideUp(300).html(data.message);
                    document.getElementById('#create-task').reset();
                }

            }
        });
        
    });
    
    //$('#task-list').load('read.php');
});

function makeElementEditable(div){
    div.style.border = "1px solid lavender";
    div.style.padding = "5px";
    div.style.background = "white";
    div.contentEditable = true;
}

function deleteTask(taskID) {
    if (confirm("Do You want to delete this task ?")) {
        $.ajax({
            url: 'delete.php', 
            method: 'POST',
            data: {id: taskID},
            success: function(data){
                $('#ajax_msg').css('display','block').delay(3000).slideUp(300).html(data);
            }
        });

        window.location.replace('tasks.php?p=1');
    }

    return false;
}

function updateTask(target, taskId, columnName) {
    var data = target.textContent;
    target.style.border = "none";
    target.style.padding = "0px";
    target.style.background = "#ececec";
    target.contentEditable = false;

    $.ajax({
        url: 'update.php', 
        method: 'POST',
        data: {theData: data, id: taskId, column: columnName},
        success: function(data){
            $('#ajax_msg').css('display','block').delay(3000).slideUp(300).html(data);
        }
    });

}