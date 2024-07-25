import { FetchData } from './price-list-get-all.fetch-data.js';
import { RenderData } from './price-list-get-all.render-data.js';

// Действия при загрузке страницы.
$(window).on('load', async function windowOnLoadHandler() {
    try {
        let response = await FetchData.getAllPriceLists();
        if (response.ok && [200, 204].some(s => s == response.status)) {
            const priceLists = response.status == 204 ? null : await response.json();
            RenderData.renderPriceListsTable(priceLists);
        }
        else {
            setTimeout(windowOnLoadHandler, recallTimeoutMs);
        }
    } catch (e) {
        setTimeout(windowOnLoadHandler, recallTimeoutMs);
        throw e;
    }   
});