export async function send(url, method = "GET", body = null, accessToken = null) {
    const headers = {
        "Accept": "application/json"
    };

    if (body !== null) {
        headers["Content-Type"] = "application/json";
    }

    if (accessToken) {
        headers["Authorization"] = `Bearer ${accessToken}`;
    }

    const response = await fetch(url, {
        method,
        credentials: "include",
        headers,
        body: body === null ? null : JSON.stringify(body)
    });

    return {
        isSuccess: response.ok,
        status: response.status,
        body: await response.text()
    };
}
