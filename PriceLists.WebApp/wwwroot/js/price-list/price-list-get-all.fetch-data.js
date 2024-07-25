export class FetchData {
    // Получить список всех прайс-листов.
    static async getAllPriceLists() {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/price-list/get-all', {
            mode: "cors",
            method: "GET"
        });
    }
}