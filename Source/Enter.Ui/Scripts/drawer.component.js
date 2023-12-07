export class DrawerComponent {
  
    open(element,direction){
        if (direction === "Start"){
            element.style.setProperty('inset-inline-start', "0");
        }
        if (direction === "End"){
            element.style.setProperty('inset-inline-end', "0");
        }
    }

    close(element,direction,width){
        if (direction === "Start"){
            element.style.setProperty('inset-inline-start', `-${width}`);
        }
        if (direction === "End"){
            element.style.setProperty('inset-inline-end', `-${width}`);
        }
        
    }
    
}

export function getDrawerComponent() {
    return new DrawerComponent();
}