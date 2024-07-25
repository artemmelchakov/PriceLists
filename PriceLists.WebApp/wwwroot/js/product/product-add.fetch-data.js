export class FetchData {
    // Создать товар.
    static async addProduct(data) {
        return await fetch(pricelistsApiHttpsHost + '/api/v1/product', {
            mode: "cors",
            method: "POST",
            headers: {
                "accept": "*/*",
                "Content-Type": "application/json"
            },
            body: data
        });
    }
}