export class ExpandableComponent {
    _dotNetRef;

    initialize(dotNetRef, id, show) {
        this._dotNetRef = dotNetRef;
        this.toggle(id, show);

    }


    toggle(id, show) {

        return;

        const expandableNode = document.getElementById(id);
        if (expandableNode) {
            if (show) {
                expandableNode.style['height'] = expandableNode.scrollHeight + "px";
            } else {
                expandableNode.style['height'] = '0';
            }
        }


    }
}

export function getExpandableComponent() {
    return new ExpandableComponent();
}