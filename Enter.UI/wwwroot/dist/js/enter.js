window.GetElementById = (id) => {
    const element = document.getElementById(id);
    return {
        width: element.offsetWidth,
        height: element.offsetHeight,
        id: element.id,
    }
};

window.GetElementByQuerySelector = (selector) => {
    const element = document.querySelector(selector);
    return {
        width: element.offsetWidth,
        height: element.offsetHeight,
        id: element.id,
    }
};