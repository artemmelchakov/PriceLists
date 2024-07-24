export class RenderData {
    // Отобразить таблицу прайс-листов.
    static renderPriceListsTable(priceLists) {
        $('.price-lists__loading-message').hide();

        if (priceLists == null) {
            $('.price-lists__empty-list-message').show();
            return;
        }

        let table = $('<table>').addClass('table').appendTo($('.price-lists'));
        table.append(`
        <thead>
            <tr class="tr__header">
                <th scope="col">№</th>
                <th scope="col">Наименование</th>
            </tr>
        </thead>`);
        let tbody = $('<tbody>').appendTo(table);
        for (var i = 0; i < priceLists.length; i++) {
            let tr = $('<tr>').appendTo(tbody);
            $('<th>').attr('scope', 'row').appendTo(tr).text(i + 1);
            $('<td>').appendTo(tr).text(priceLists[i].name);
        }
    }
}