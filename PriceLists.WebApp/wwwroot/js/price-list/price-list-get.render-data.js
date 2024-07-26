export class RenderData {
    // Отобразить прайс-лист.
    static renderPriceList(priceList, productDeletingButtonClickHandler) {
        $('.price-list').show();
        $('.price-list__name').text(priceList.name);
        let trHeader = $('.tr__header');

        // Отрисовка кастомных колонок.
        for (let column of priceList.columns) {
            $('<th>').attr('scope', 'col').text(`${column.name} (${column.typeName})`).appendTo(trHeader);
        }

        // Добавить столбец для кнопок удаления.
        $('<th>').attr('scope', 'col').appendTo(trHeader);

        // Отрисовка данных о товаре и добавление кнопки "Удалить" напротив каждого товара.
        let tbody = $('.price-list tbody');
        for (let product of priceList.products) {
            let tr = $('<tr>').appendTo(tbody);
            $('<td>').text(product.name).appendTo(tr);
            $('<td>').text(product.code).appendTo(tr);
            for (let columnValue of product.columnValues) {
                $('<td>').text(columnValue.value).appendTo(tr);
            }
            let deletingTd = $('<td>').appendTo(tr);
            $('<button>')
                .addClass('price-list__product-deleting-button btn btn-danger')
                .attr({ type: 'button', 'data-bs-toggle': 'modal', 'data-bs-target': '#productDeletingModal' })
                .text('Удалить')
                .on('click', () => productDeletingButtonClickHandler(tr, product.id))
                .appendTo(deletingTd);
        }
    }

    // Удалить строку удаленного товара.
    static deleteProductTr(tr) {
        tr.remove();
    }

    // Показать уведомление о том, что удалить товар не удалось.
    static showProductDeletingErrorMessage() {
        $('.product-deleting__error-message').show();
    }

    // Скрыть уведомление о том, что удалить товар не удалось.
    static hideProductDeletingErrorMessage() {
        $('.product-deleting__error-message').hide();
    }
}