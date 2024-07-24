export class RenderData {
    // Отобразить список уже существующих в БД кастомных колонок.
    static renderExistingColumns(columns) {
        if (columns == null) {
            return;
        }
        let columnsSelect = $('select[name="price-list-add-form__existing-columns"]');
        for (let column of columns) {
            $('<option>').attr('value', column.id).text(column.name + ' (' + column.typeName + ')').appendTo(columnsSelect);
        }
    }

    static renderDefaultOptionInExistingColumns() {
        $('select[name="price-list-add-form__existing-columns"]').val('default-option');
    }

    // Отобразить выбранную добавленную для текущего прайс-листа существующую кастомную колонку.
    static renderAddedColumn(column, deleteFromSetHandler) {
        let addedColumnsDiv = $('.price-list-add-form__existing-added-columns').show();
        let row = $('<div>').addClass('row').appendTo(addedColumnsDiv);
        $('<div>').addClass('col-xl').text(column.name).appendTo(row);
        $('<div>').addClass('col-xl').text(column.typeName).appendTo(row);
        let deletingColumn = $('<div>').addClass('col-xl').appendTo(row);
        $('<button>').addClass('price-list-add-form__deleting-button').attr('type', 'button').text('Удалить').on('click', function () {
            deleteFromSetHandler();
            row.remove();
        }).appendTo(deletingColumn);
    }

    // Отобразить строку для создания новой колонки.
    static renderNewColumnRow(deleteFromSetHandler) {
        let newColumnsDiv = $('.price-list-add-form__new-added-columns').show();
        let row = $('<div>').addClass('row').appendTo(newColumnsDiv);
        // Имя колонки
        let columnNameDiv = $('<div>').addClass('col-xl').appendTo(row);
        let columnNameEl =
            $('<input class="form-control" type="text" name="column-name" placeholder="Имя колонки" />').appendTo(columnNameDiv);
        // Тип колонки
        let columnTypeDiv = $('<div>').addClass('col-xl').appendTo(row);
        let columnTypeEl = $(`
        <select name="column-type" class="form-select">
            <option value="0">Число</option>
            <option value="1">Строка</option>
            <option value="2">Текст</option>
        </select>`).appendTo(columnTypeDiv);
        let deletingColumn = $('<div>').addClass('col-xl').appendTo(row);
        let columnEl = { nameEl: columnNameEl, typeEl: columnTypeEl };
        $('<button>').addClass('price-list-add-form__deleting-button').attr('type', 'button').text('Удалить').on('click', function () {
            deleteFromSetHandler(columnEl);
            row.remove();
        }).appendTo(deletingColumn);
        return columnEl;
    }

    // Показать сообщение об ошибке.
    static showErrorMessage() {
        $('.price-list-adding__error-message').show();
    }

    // Скрыть сообщение об ошибке.
    static hideErrorMessage() {
        $('.price-list-adding__error-message').hide();
    }
}