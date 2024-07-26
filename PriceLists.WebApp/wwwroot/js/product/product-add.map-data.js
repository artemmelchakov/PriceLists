export class MapData {
    // Получить информацию для создания товара.
    static mapProduct() {
        let name = $('input[name="name"]').val();
        let code = $('input[name="code"]').val();
        let rowElements = $('.product-add-form__column-value-row');

        let requestBody = {
            name: name,
            code: parseInt(code),
            priceListId: parseInt(priceListId),
            columnValues: []
        }

        for (let rowEl of rowElements) {
            let columnId = $(rowEl).find('input[name="columnId"]').val();
            let value = $(rowEl).find('*[name="columnValue"]').val();
            requestBody.columnValues.push({ value: value, columnId: parseInt(columnId) });
        }

        return JSON.stringify(requestBody);
    }
}