import { FetchData } from './product-add.fetch-data.js';
import { MapData } from './product-add.map-data.js';
import { RenderData } from './product-add.render-data.js';

// Действия при нажатии кнопки сохранения товара.
$('.product-add-form__saving-button').on('click', async function () {
    RenderData.hideErrorMessage();    
    let data = MapData.mapProduct();
    let response = await FetchData.addProduct(data);
    if (response.ok && response.status == 200) {
        $.redirect('/price-list/get/' + priceListId);
    }
    else {
        RenderData.showErrorMessage();        
    }
});

// Действия при нажатии кнопки возвращения к прайс-листу.
$('.back-to-price-list').on('click', async function () {
    $.redirect('/price-list/get/' + priceListId);
});