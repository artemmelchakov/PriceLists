import { FetchData } from './price-list-add.fetch-data.js';
import { MapData } from './price-list-add.map-data.js';
import { RenderData } from './price-list-add.render-data.js';

let existingColumns = [];
let addedColumns = new Set();
let newColumnsElements = new Set();

// Действия при загрузке страницы.
$(window).on('load', async function windowOnLoadHandler() {
    try {
        let response = await FetchData.getAllColumns();
        if (response.status == 200) {
            existingColumns = await response.json();
            RenderData.renderExistingColumns(existingColumns);
        }
    } catch (e) {
        setTimeout(windowOnLoadHandler, recallTimeoutMs);
        throw e;
    }
});

// Действия при выборе существующей кастомной колонки из списка.
$('select[name="price-list-add-form__existing-columns"]').on('change', async function () {
    let existingColumnId = this.value;
    let column = existingColumns.find(c => c.id == existingColumnId);

    if (column != undefined) {
        if (!addedColumns.has(column)) {
            addedColumns.add(column);
            RenderData.renderAddedColumn(column, function () { addedColumns.delete(column); });
            
        }
    }
    RenderData.renderDefaultOptionInExistingColumns();
});

// Действия при нажатии кнопки формы, которая создаёт прайс-лист.
$('.price-list-add-form__saving-button').on('click', async function () {
    RenderData.hideErrorMessage();
    let data = MapData.mapPriceListFromForm(addedColumns, newColumnsElements);
    let response = await FetchData.addPriceList(data);
    if (response.ok && response.status == 200) {
        $.redirect('/price-list/get-all');
    }
    else {
        RenderData.showErrorMessage();
    }
});

// Действия при нажатии кнопки создания новой колонки.
$('.price-list-add-form__new-column-button').on('click', async function () {
    let columnEl = RenderData.renderNewColumnRow(function (columnEl) { newColumnsElements.delete(columnEl); });
    newColumnsElements.add(columnEl);
});