export class RenderData {
    // Отобразить таблицу прайс-листов.
    static renderPriceListsTable(priceLists) {
        $('.price-lists__loading-message').hide();

        if (priceLists.length == 0) {
            $('.price-lists__empty-list-message').show();
            return;
        }

        $('.price-lists table').show();
        let tbody = $('.price-lists tbody');
        for (var i = 0; i < priceLists.length; i++) {
            let tr = $('<tr>').appendTo(tbody);
            $('<th>').attr('scope', 'row').text(i + 1).appendTo(tr);
            let td = $('<td>').appendTo(tr);
            $('<a>').attr('href', '/price-list/get/' + priceLists[i].id).text(priceLists[i].name).appendTo(td);
        }
    }
}