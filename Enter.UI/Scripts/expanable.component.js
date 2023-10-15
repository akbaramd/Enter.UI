export class ExpandableComponent {
    _dotNetRef;

    initialize(dotNetRef, id , show) {
        this._dotNetRef = dotNetRef;
        this.toggle(id, show);
    }


    toggle(id, show) {
        
        
        
        const expandableNode = document.getElementById(id);
        console.log(id,show);
        if (expandableNode) {
            if (show) {
                expandableNode.style['height'] = "auto";
            } else {
                expandableNode.style['height'] = '0';
            }
        }
    }
}

export function getExpandableComponent() {
    return new ExpandableComponent();
}