export class FetchData {
    // Получить прайс-лист.
    static async getPriceList(id) {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/price-list/' + id, {
            mode: "cors",
            method: "GET"
        });
    }

    // Удалить товар из текущего прайс-листа.
    static async deleteProduct(id) {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/product/' + id, {
            mode: "cors",
            method: "DELETE"
        });
    }
}