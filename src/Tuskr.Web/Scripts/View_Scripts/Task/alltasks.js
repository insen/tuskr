window.tuskr = window.tuskr || {};


(function (alltasks, $, undefined) {
    var dlgopts = {
        dialogClass: 'opaque',
        height: 'auto',
        width: 400,
        modal: true,
        position: ['relative'],
        autoOpen: false,
        closeOnEscape: false,
        open: function() {
            window.tuskr.addTask.init(alltasks, $('#template-add'));
        }
    };

    alltasks.resume = function() {
        $('.b-data').show();
    };
    
    alltasks.suspend = function () {
        $('.b-data').hide();
    };

    alltasks.init = function () {
        $('.b-hdr .icon').click(function () {
            $('#template-add').dialog(dlgopts);
            $('#template-add').dialog('open');
            alltasks.suspend();
        });
        
        $('.task-gp-hdr').click(function () {
            var header = $(this).closest('tr');
            var elements = $('tbody [data-group-reference=' + header.attr('id') + ']');

            elements.toggle('toggle');
            return false;
        });
    };
}(window.tuskr.allTasks = window.tuskr.allTasks || {}, jQuery));


$(document).ready(function () {
    window.tuskr.allTasks.init();
});
