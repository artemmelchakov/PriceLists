import { FetchData } from './price-list-get-all.fetch-data.js';
import { RenderData } from './price-list-get-all.render-data.js';

// Действия при загрузке страницы.
$(window).on('load', async function () {
    const priceLists = await FetchData.getAllPriceLists();
    RenderData.renderPriceListsTable(priceLists);        
});