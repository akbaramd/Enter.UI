

export const  Initilize = (ref,sidebarIsShow,mobileBreakSize) => {

    const sidebar = document.querySelector(".ent-layout-sidebar");

    function handleResize() {
        if (window.innerWidth < mobileBreakSize) {
            sidebar.classList.add("ent-layout-sidebar-overlap");
            ref.invokeMethodAsync('CloseSidebarAsync');
        } else {
            sidebar.classList.remove("ent-layout-sidebar-overlap");
            ref.invokeMethodAsync('OpenSidebarAsync');
        }
    }
    handleResize();
    Toggle(ref,sidebarIsShow);
    window.addEventListener('resize', handleResize);
}

export const  Toggle = (ref,sidebarIsShow) => {

    const sidebar = document.querySelector(".ent-layout-sidebar");

    sidebar.style.transition = "all 0.25s ease-in"; // Reset any previous transformations
    
    if (sidebarIsShow) {
        sidebar.classList.add("show");
        sidebar.style.marginInlineStart = 0; // Reset any previous transformations

    } else {
        sidebar.classList.remove("show");
        sidebar.style.marginInlineStart = `-${sidebar.offsetWidth}px`; // Slide sidebar out of view
    }
}
export default  {
    Initilize,
    Toggle
};


