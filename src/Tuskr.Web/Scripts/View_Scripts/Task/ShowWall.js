window.tuskr = window.tuskr || {};

window.tuskr.ShowWall = function () {
    var srcContainer = {};

    var postStatusChanges = function (ui, sink) {
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

    var toTask = function ($elem) {
        var task = {};
        var $sources = $elem.find('input');
        
        task.Id = $elem.attr('id');
        task.Name = $sources.filter('.t-main').val();
        task.Description = $sources.filter('.t-desc').val();
        task.StartDate = $sources.filter('.t-start').val();
        task.Duration = $sources.filter('.t-duration').val();
        task.Status = $sources.filter('.t-status').val();

        return task;
    };

    var updateUi = function($taskDiv, task) {
        var $targets = $taskDiv.find('>div:not(:has(> .input))');

        $targets.filter('.t-main').text(task.Name);
        $targets.filter('.t-desc').text(task.Description);
        $targets.filter('.t-start').text(task.StartDate);
        $targets.filter('.t-duration').text(task.Duration);
        $targets.filter('.t-status').text(task.Status);
    };

    var postEdit = function ($elem) {
        var $taskDiv = $elem.parent().parent();
        var task = toTask($taskDiv);

        $.ajax({
            url: '/Task/EditTask',
            type: 'POST',
            dataType: 'json',
            async: true,
            contentType: 'application/json; charset=utf-8',
            data: JSON.stringify(task),
            success: function () {
                toggleShowHide($elem.parent().siblings());
                setupForEdit($elem);
                updateUi($taskDiv, task);
            },
            failure: function () {
                alert('fail');
            }
        });
    };

    var toggleShowHide = function ($elements) {
        var $hiddens = $elements.find('.hide');
        var $visibles = $elements.find('.show');
        
        $hiddens.each(function() {
            $(this).removeClass('hide').addClass('show');
        });
        
        $visibles.each(function () {
            $(this).removeClass('show').addClass('hide');
        });
    };

    var setupForEdit = function ($elem) {
        $elem.text("Edit");
        $elem.off('click');
        
        $elem.click(function() {
            //toggleShowHide($(this).parent().siblings());
            toggleShowHide($(this).parents('.t-elements'));
            setupForSave($(this));
            
        });
    };

    var setupForSave = function ($elem) {
        $elem.removeClass('t-edit').addClass('t-save');
        $elem.text("Save");
        $elem.off('click');
        
        $elem.click(function () {
            postEdit($elem);
        });
    };
    
    this.init = function () {

        $('div.t-options').find('.t-edit').each(function() {
            setupForEdit($(this));
        });
        
        $('div.t-elements').each(function() {
            $(this).draggable({
                revert: true,
                start: function(ev, ui) {
                    var parents = $(ui.helper).parents();
                    srcContainer = parents.closest('div.lane-label');
                }
            });
        });

        $('div.t-group').each(function() {
            $(this).droppable({
                drop: function(ev, ui) {
                    var sink = $(this);

                    if (!isAllowed(ui, sink)) {
                        alert("transition not allowed");
                        return;
                    }

                    sink.append(ui.draggable);
                    postStatusChanges(ui, sink);
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

