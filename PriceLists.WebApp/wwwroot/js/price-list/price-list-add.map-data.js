export class MapData {
    // Получить информацию из формы для создания прайс-листа.
    static mapPriceListFromForm(addedColumns, newColumnsElements) {        
        let requestBody = {
            name: $('.price-list-add-form input[name="name"]').val(),
            columns: Array.from(addedColumns)
        }
        let newColumns =
            Array.from(newColumnsElements).map(columnEl => { return { name: columnEl.nameEl.val(), type: parseInt(columnEl.typeEl.val()) } });
        newColumns.forEach(nc => requestBody.columns.push(nc));
        return JSON.stringify(requestBody);
    }
}