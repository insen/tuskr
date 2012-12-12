window.tuskr = window.tuskr || {};

window.tuskr.ShowWall = function () {
    var srcContainer = {};

    var post = function (ui, sink) {
        var itemkey = $(ui.draggable).attr('id');
        var itemStatus = $('em', sink).text();

        $.ajax({
            url: '/Task/EditStatus',
            type: 'POST',
            dataType: 'json',
            async: true,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify({ Id: itemkey, Status: itemStatus }),
            success: function () {
                sink.append(ui.draggable);
            },
            failure: function () {
                srcContainer.append(ui.draggable);
            }
        });
    };

    var isAllowed = function(ui, sink) {
        var from = $('div.t-status', ui.draggable).text();
        var to = $('em', sink).text();

        if (from == 'Done') return false;
        if (from == 'Undefined' && to == 'Done') return false;
        return true;
    };

    this.init = function() {
        $('div.task-wall-item').each(function() {
            $(this).draggable({
                revert: true,
                start: function(ev, ui) {
                    var parents = $(ui.helper).parents();
                    srcContainer = parents.closest('div.lane-label');
                }
            });
        });

        $('div.task-wall-container').each(function() {
            $(this).droppable({
                //tolerance: 'touch',
                drop: function(ev, ui) {
                    var sink = $(this);

                    if (!isAllowed(ui, sink)) {
                        alert("transition not allowed");
                        return;
                    }

                    sink.append(ui.draggable);
                    post(ui, sink);
                }
            });
        });
    };

    return this;
};

$(document).ready(function () {
    var mod = new window.tuskr.ShowWall();
    mod.init();
});

