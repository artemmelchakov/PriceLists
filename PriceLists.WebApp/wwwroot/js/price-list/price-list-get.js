import { FetchData } from './price-list-get.fetch-data.js';
import { RenderData } from './price-list-get.render-data.js';

let priceList = new Object();

// Действия при загрузке страницы.
$(window).on('load', async function () {
    priceList = await FetchData.getPriceList(priceListId);
    RenderData.renderPriceList(priceList, productDeletingButtonClickHandler);
});

// Обработчик события нажатия кнопки удаления товара.
function productDeletingButtonClickHandler(tr, id) {
    RenderData.hideProductDeletingErrorMessage();
    $('.confirm-product-deleting').off('click').on('click', async function () {
        let response = await FetchData.deleteProduct(id);
        if (response.ok && response.status == 200) {
            RenderData.deleteProductTr(tr);
        }
        else {
            RenderData.showProductDeletingErrorMessage();
        }
    });
}

// Действия при нажатии кнопки создания товара.
$('.price-list__product-adding-button').on('click', async function () {
    $.redirect('/product/add', { priceListId: priceList.id, columns: priceList.columns }, "POST");
});