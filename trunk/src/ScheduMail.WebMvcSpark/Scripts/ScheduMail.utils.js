var wysiwyg = {
    bind: function() {
        $('textarea.wysiwyg').each(function() {
            if ($(this).val().indexOf('<') == 0)
                $(this).markItUp(htmlSettings);
            else
                $(this).markItUp(markdownSettings);
        });
    }
};