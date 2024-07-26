import { FetchData } from './price-list-get-all.fetch-data.js';
import { RenderData } from './price-list-get-all.render-data.js';

// Действия при загрузке страницы.
$(window).on('load', async function windowOnLoadHandler() {
    try {
        let response = await FetchData.getAllPriceLists();
        if (response.status == 200) {
            const priceLists = await response.json();
            RenderData.renderPriceListsTable(priceLists);
        }
    } catch (e) {
        setTimeout(windowOnLoadHandler, recallTimeoutMs);
        throw e;
    }   
});