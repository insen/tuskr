window.tuskr = window.tuskr || {};

(function (alltasks, $, undefined) {
    var isPrivateMember = true;
    
    alltasks.ingredient = "Bacon Strips";

    alltasks.init = function() {
        $('.task-gp-hdr').click(function () {
            var header = $(this).closest('tr');
            var elements = $('tbody [data-group-reference=' + header.attr('id') + ']');

            //$('#' + rowid).slideToggle('slow');
            //elements.slideToggle('slow');
            elements.toggle('toggle');
            return false;
        });
    };
}(window.tuskr.allTasks = window.tuskr.allTasks || {}, jQuery));


$(document).ready(function () {
    window.tuskr.allTasks.init();
});
