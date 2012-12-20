window.tuskr = window.tuskr || {};

window.tuskr.taskHeader = function() {
    var dlgopts = {
        height: 'auto',
        width: 400,
        modal: true,
        position: ['relative'],
        autoOpen: false,
        closeOnEscape: false,
        open: function() {
            onDialogOpen();
        }
    };
    
    var onDialogOpen = function() {
        var $dialog = $('#template-add');

        $('#submit', $dialog).click(function (e) {
            e.preventDefault();
            postNewTask($('form'));
        });

        $('#close', $dialog).click(function() {
            $dialog.dialog('close');
            $('.b-data').show();
        });
    };

    var postNewTask = function ($form) {
        $.ajax({
            url: $form.attr('action'),
            type: $form.attr('method'),
            data: $form.serialize(),
            success: function (output) {
                alert(output);
            },
            error: function () {
                alert('error occured!');
            }
        });
    };

    this.init = function () {
        $('.b-hdr .add').click(function() {
            $('#template-add').dialog(dlgopts);
            $('#template-add').dialog('open');
            $('.b-data').hide();
        });
    };
};

$(document).ready(function () {
    var module = new window.tuskr.taskHeader();
    module.init();
});