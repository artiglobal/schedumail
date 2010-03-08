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
		{ name: 'Clean', className: 'clean', replaceWith: function(markitup) { return markitup.selection.replace(/<(.*?)>/g, "") } },
		{ separator: '---------------' },
		{ name: 'Preview', className: 'preview', call: 'preview' }
	]
};
