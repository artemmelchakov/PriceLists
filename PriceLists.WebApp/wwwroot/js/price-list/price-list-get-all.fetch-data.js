export class FetchData {
    // Получить список всех прайс-листов.
    static async getAllPriceLists() {
        let response = await fetch(pricelistsApiHttpsHost + '/api/v1/price-list/get-all', {
            mode: "cors",
            method: "GET"
        });
        return response.status == 204 ? null : response.json();
    }
}