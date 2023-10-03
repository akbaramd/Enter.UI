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

}


export function getShared() {
    return new Shared();
}