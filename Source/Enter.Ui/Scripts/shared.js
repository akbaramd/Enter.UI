export class Shared {

    _currentBreakpoint = "";

    GetElementById(id) {
        const element = document.getElementById(id);
        return {
            width: element.offsetWidth,
            height: element.offsetHeight,
            id: element.id,
        }
    }

    GetElementByQuerySelector(selector) {
        const element = document.querySelector(selector);
        return {
            width: element.offsetWidth,
            height: element.offsetHeight,
            id: element.id,
        }
    }

    setAttributeByQuerySelector(selector, key, value) {
        document.querySelector(selector).setAttribute(key, value)
    }

    getBoundingClientRect(element) {
        console.log(element);



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

    getBreakpoint() {
        return this.calculateBreakpoint(window.innerWidth);
    }

    initializeBreakpointEvent(dotNetRef) {

        this._currentBreakpoint = this.calculateBreakpoint(window.innerWidth);

        dotNetRef.invokeMethodAsync('OnBreakpointEventListener', this._currentBreakpoint);


        addEventListener("resize", (event) => {
            let breakpoint = this.calculateBreakpoint(window.innerWidth);
            if (this._currentBreakpoint !== breakpoint) {
                this._currentBreakpoint = breakpoint;
                dotNetRef.invokeMethodAsync('OnBreakpointEventListener', this._currentBreakpoint);
            }
        });
    }


    calculateBreakpoint(innerWidth) {
        if (innerWidth < 768) {
            return "Mobile";
        } else if (768 <= innerWidth && innerWidth < 992) {
            return "Tablet";
        } else if (992 <= innerWidth && innerWidth < 1200) {
            return "Laptop";
        } else if (1200 <= innerWidth && innerWidth < 1400) {
            return "Desktop";
        } else if (1400 <= innerWidth) {
            return "Screen";
        }

        return "Screen";

    }

}


export function getShared() {
    return new Shared();
}