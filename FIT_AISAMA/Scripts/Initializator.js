var InitHelper = {
    defaultDatePicker: function() {
        $("[id *= Date]").datetimepicker({
            locale: 'ru',
            format: 'DD.MM.YYYY'
        });
    }
}