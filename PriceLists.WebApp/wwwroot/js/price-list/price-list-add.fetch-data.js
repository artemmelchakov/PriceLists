export class FetchData {
    // Создать прайст-лист.
    static async addPriceList(data) {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/price-list', {
            mode: "cors",
            method: "POST",
            headers: { 
                "accept": "*/*",
                "Content-Type": "application/json"
            },
            body: data
        });
    }

    // Получить список всех прайс-листов.
    static async getAllColumns() {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/column/get-all', {
            mode: "cors",
            method: "GET"
        });
    }
}