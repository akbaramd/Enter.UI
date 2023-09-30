import  Layout from './components/layout.component';
window.EnterUi = {
    Components: {
        Layout 
    },
    Shared:{
        GetElementById (id) {
            const element = document.getElementById(id);
            return {
                width: element.offsetWidth,
                height: element.offsetHeight,
                id: element.id,
            }
        },
        GetElementByQuerySelector  (selector)  {
            const element = document.querySelector(selector);
            return {
                width: element.offsetWidth,
                height: element.offsetHeight,
                id: element.id,
            }
        }
    }
}

