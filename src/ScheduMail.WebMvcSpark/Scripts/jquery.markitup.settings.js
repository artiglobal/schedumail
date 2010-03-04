htmlSettings = {
    nameSpace: "miu_html", // Useful to prevent multi-instances CSS conflict
    onShiftEnter: { keepDefault: false, replaceWith: '<br />\n' },
    onCtrlEnter: { keepDefault: false, openWith: '\n<p>', closeWith: '</p>\n' },
    onTab: { keepDefault: false, openWith: '	 ' },
    markupSet: [
		{ name: 'Bold', key: 'B', openWith: '(!(<strong>|!|<b>)!)', closeWith: '(!(</strong>|!|</b>)!)' },
		{ name: 'Italic', key: 'I', openWith: '(!(<em>|!|<i>)!)', closeWith: '(!(</em>|!|</i>)!)' },
		{ name: 'Stroke through', key: 'S', openWith: '<del>', closeWith: '</del>' },
		{ separator: '---------------' },
		{ name: 'Paragraph', openWith: '<p(!( class="[![Class]!]")!)>', closeWith: '</p>' },
		{ name: 'Ul', openWith: '<ul>\n', closeWith: '</ul>\n' },
		{ name: 'Ol', openWith: '<ol>\n', closeWith: '</ol>\n' },
		{ name: 'Li', openWith: '<li>', closeWith: '</li>' },
		{ separator: '---------------' },
		{ name: 'Picture', key: 'P', replaceWith: '<img src="[![Source:!:http://]!]" alt="[![Alternative text]!]" />' },
		{ name: 'Link', key: 'L', openWith: '<a href="[![Link:!:http://]!]"(!( title="[![Title]!]")!)>', closeWith: '</a>', placeHolder: 'Your text to link...' },
		{ separator: '---------------' },
		{ name: 'Clean', className: 'clean', replaceWith: function(markitup) { return markitup.selection.replace(/<(.*?)>/g, "") } },
		{ separator: '---------------' },
		{ name: 'Table',
		    openWith: '<table>',
		    closeWith: '</table>',
		    placeHolder: "<tr><(!(td|!|th)!)></(!(td|!|th)!)></tr>",
		    className: 'table'
		},
		{ name: 'Tr',
		    openWith: '<tr>',
		    closeWith: '</tr>',
		    placeHolder: "<(!(td|!|th)!)></(!(td|!|th)!)>",
		    className: 'table-col'
		},
		{ name: 'Td/Th',
		    openWith: '<(!(td|!|th)!)>',
		    closeWith: '</(!(td|!|th)!)>',
		    className: 'table-row'
		},
		{ separator: '---------------' },
		{ name: 'Preview', className: 'preview', call: 'preview' }
	]
};

// mIu nameSpace to avoid conflict.
miu = {
    setMarkdown: function(markItUp) {
        var $markItUp = $(markItUp.textarea);
        $markItUp.markItUpRemove();
        $markItUp.markItUp(markdownSettings);
        return false;
    },
    setHTML: function(markItUp) {
        var $markItUp = $(markItUp.textarea);
        $markItUp.markItUpRemove();
        $markItUp.markItUp(htmlSettings);
        return false;
    },
    remove: function(markItUp) {
        $(markItUp.textarea).markItUpRemove();
        return false;
    }
};
