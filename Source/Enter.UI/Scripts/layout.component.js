 export class LayoutComponent {
    _dotNetRef;
    _sidebar;
    _layoutBreakWidth;
    initialize(dotNetRef, sidebarIsShow, layoutBreakWidth) {

        console.log("start initialize LayoutComponent");
        
        this._dotNetRef = dotNetRef;
        this._layoutBreakWidth = layoutBreakWidth;
  
        this._sidebar = document.querySelector(".ent-layout-sidebar");

        this.handleResize(this._sidebar,this._layoutBreakWidth); 
        this.toggleSidebar(sidebarIsShow);

        window.addEventListener('resize', ()=>this.handleResize(this._sidebar,this._layoutBreakWidth));
    }

    toggleSidebar(sidebarIsShow) {
        this._sidebar.style.transition = "all 0.25s ease-in";

        if (sidebarIsShow) {
            this._sidebar.classList.add("show");
            this._sidebar.style.marginInlineStart = 0; // Reset any previous transformations
        } else {
            this._sidebar.classList.remove("show");
            this._sidebar.style.marginInlineStart = `-${this._sidebar.offsetWidth}px`; // Slide sidebar out of view
        }
    }

    handleResize(_sidebar,_layoutBreakWidth) {
        
        if (window.innerWidth < this._layoutBreakWidth) {
            this._sidebar.classList.add("ent-layout-sidebar-overlap");
            this._dotNetRef.invokeMethodAsync('CloseSidebarAsync');
        } else {
            this._sidebar.classList.remove("ent-layout-sidebar-overlap");
            this._dotNetRef.invokeMethodAsync('OpenSidebarAsync');
        }
    }

}

export function getLayoutComponent() {
    return new LayoutComponent();
}