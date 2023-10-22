export class Shared {

    GetElementById (id) {
        const element = document.getElementById(id);
        return {
            width: element.offsetWidth,
            height: element.offsetHeight,
            id: element.id,
        }
    }
    GetElementByQuerySelector  (selector)  {
        const element = document.querySelector(selector);
        return {
            width: element.offsetWidth,
            height: element.offsetHeight,
            id: element.id, 
        }
    }

    getBoundingClientRect(element) {
        if (!element) return;

        var rect = JSON.parse(JSON.stringify(element.getBoundingClientRect()));

        rect.scrollY = window.scrollY || document.documentElement.scrollTop;
        rect.scrollX = window.scrollX || document.documentElement.scrollLeft;
        rect.scrollHeight = element.scrollHeight;
        rect.scrollWidth = element.scrollWidth;
        rect.windowHeight = window.innerHeight;
        rect.windowWidth = window.innerWidth;
        return rect;
    }

}


export function getShared() {
    return new Shared();
}