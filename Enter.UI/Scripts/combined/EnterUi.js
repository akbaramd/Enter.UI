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
export class PopOverComponent {
_dotNetRef;
_map = {};
flipMargin = 0;
flipClassReplacements =  {
'top': {
'ent-popover-top-left': 'ent-popover-bottom-left',
'ent-popover-top-center': 'ent-popover-bottom-center',
'ent-popover-anchor-bottom-center': 'ent-popover-anchor-top-center',
'ent-popover-top-right': 'ent-popover-bottom-right',
},
'left': {
'ent-popover-top-left': 'ent-popover-top-right',
'ent-popover-center-left': 'ent-popover-center-right',
'ent-popover-anchor-center-right': 'ent-popover-anchor-center-left',
'ent-popover-bottom-left': 'ent-popover-bottom-right',
},
'right': {
'ent-popover-top-right': 'ent-popover-top-left',
'ent-popover-center-right': 'ent-popover-center-left',
'ent-popover-anchor-center-left': 'ent-popover-anchor-center-right',
'ent-popover-bottom-right': 'ent-popover-bottom-left',
},
'bottom': {
'ent-popover-bottom-left': 'ent-popover-top-left',
'ent-popover-bottom-center': 'ent-popover-top-center',
'ent-popover-anchor-top-center': 'ent-popover-anchor-bottom-center',
'ent-popover-bottom-right': 'ent-popover-top-right',
},
'top-and-left': {
'ent-popover-top-left': 'ent-popover-bottom-right',
},
'top-and-right': {
'ent-popover-top-right': 'ent-popover-bottom-left',
},
'bottom-and-left': {
'ent-popover-bottom-left': 'ent-popover-top-right',
},
'bottom-and-right': {
'ent-popover-bottom-right': 'ent-popover-top-left',
},
}
constructor() {
window.addEventListener('scroll', () => {
this.placePopoverByClassSelector('ent-popover-fixed');
this.placePopoverByClassSelector('ent-popover-overflow-flip-always');
});
window.addEventListener('resize', () => {
this.placePopoverByClassSelector();
});
}
initialize(dotNetRef, id) {
console.log("start initialize PopOverComponent");
this._dotNetRef = dotNetRef;
}
getPositionForFlippedPopver(inputArray, selector, boundingRect, selfRect) {
const classList = [];
for (var i = 0; i < inputArray.length; i++) {
const item = inputArray[i];
const replacments = this.flipClassReplacements[selector][item];
if (replacments) {
classList.push(replacments);
} else {
classList.push(item);
}
}
return this.calculatePopoverPosition(classList, boundingRect, selfRect);
}
calculatePopoverPosition(list, boundingRect, selfRect) {
let top = 0;
let left = 0;
if (list.indexOf('ent-popover-anchor-top-left') >= 0) {
left = boundingRect.left;
top = boundingRect.top;
} else if (list.indexOf('ent-popover-anchor-top-center') >= 0) {
left = boundingRect.left + boundingRect.width / 2;
top = boundingRect.top;
} else if (list.indexOf('ent-popover-anchor-top-right') >= 0) {
left = boundingRect.left + boundingRect.width;
top = boundingRect.top;
} else if (list.indexOf('ent-popover-anchor-center-left') >= 0) {
left = boundingRect.left;
top = boundingRect.top + boundingRect.height / 2;
} else if (list.indexOf('ent-popover-anchor-center-center') >= 0) {
left = boundingRect.left + boundingRect.width / 2;
top = boundingRect.top + boundingRect.height / 2;
} else if (list.indexOf('ent-popover-anchor-center-right') >= 0) {
left = boundingRect.left + boundingRect.width;
top = boundingRect.top + boundingRect.height / 2;
} else if (list.indexOf('ent-popover-anchor-bottom-left') >= 0) {
left = boundingRect.left;
top = boundingRect.top + boundingRect.height;
} else if (list.indexOf('ent-popover-anchor-bottom-center') >= 0) {
left = boundingRect.left + boundingRect.width / 2;
top = boundingRect.top + boundingRect.height;
} else if (list.indexOf('ent-popover-anchor-bottom-right') >= 0) {
left = boundingRect.left + boundingRect.width;
top = boundingRect.top + boundingRect.height;
}
let offsetX = 0;
let offsetY = 0;
if (list.indexOf('ent-popover-top-left') >= 0) {
offsetX = 0;
offsetY = 0;
} else if (list.indexOf('ent-popover-top-center') >= 0) {
offsetX = -selfRect.width / 2;
offsetY = 0;
} else if (list.indexOf('ent-popover-top-right') >= 0) {
offsetX = -selfRect.width;
offsetY = 0;
} else if (list.indexOf('ent-popover-center-left') >= 0) {
offsetX = 0;
offsetY = -selfRect.height / 2;
} else if (list.indexOf('ent-popover-center-center') >= 0) {
offsetX = -selfRect.width / 2;
offsetY = -selfRect.height / 2;
} else if (list.indexOf('ent-popover-center-right') >= 0) {
offsetX = -selfRect.width;
offsetY = -selfRect.height / 2;
} else if (list.indexOf('ent-popover-bottom-left') >= 0) {
offsetX = 0;
offsetY = -selfRect.height;
} else if (list.indexOf('ent-popover-bottom-center') >= 0) {
offsetX = -selfRect.width / 2;
offsetY = -selfRect.height;
} else if (list.indexOf('ent-popover-bottom-right') >= 0) {
offsetX = -selfRect.width;
offsetY = -selfRect.height;
}
return {
top: top, left: left, offsetX: offsetX, offsetY: offsetY
};
}
getAllObservedContainers() {
const result = [];
for (var i in this._map) {
result.push(i);
}
return result;
}
placePopoverByClassSelector(classSelector = null) {
var items = this.getAllObservedContainers();
for (let i = 0; i < items.length; i++) {
const popoverNode = document.getElementById('ent-popover-' + items[i]);
this.placePopover(popoverNode, classSelector);
}
}
placePopoverByNode(target) {
const id = target.id.substr(20);
const popoverNode = document.getElementById('ent-popover-' + id);
this.placePopover(popoverNode);
}
placePopover(popoverNode, classSelector) {
if (popoverNode && popoverNode.parentNode) {
const id = popoverNode.id.substr(12);
const popoverContentNode = document.getElementById('ent-popover-content-' + id);
if (!popoverContentNode) {
return;
}
if (popoverContentNode.classList.contains('ent-popover-open') == false) {
return;
}
if (classSelector) {
if (popoverContentNode.classList.contains(classSelector) == false) {
return;
}
}
const boundingRect = popoverNode.parentNode.getBoundingClientRect();
if (popoverContentNode.classList.contains('ent-popover-relative-width')) {
popoverContentNode.style['max-width'] = (boundingRect.width) + 'px';
}
const selfRect = popoverContentNode.getBoundingClientRect();
const classList = popoverContentNode.classList;
const classListArray = Array.from(popoverContentNode.classList);
const postion = this.calculatePopoverPosition(classListArray, boundingRect, selfRect);
console.log(classListArray)
let left = postion.left;
let top = postion.top;
let offsetX = postion.offsetX;
let offsetY = postion.offsetY;
if (classList.contains('ent-popover-overflow-flip-onopen') || classList.contains('ent-popover-overflow-flip-always')) {
const appBarElements = document.getElementsByClassName("ent-appbar ent-appbar-fixed-top");
let appBarOffset = 0;
if (appBarElements.length > 0) {
appBarOffset = appBarElements[0].getBoundingClientRect().height;
}
const graceMargin = this.flipMargin;
const deltaToLeft = left + offsetX;
const deltaToRight = window.innerWidth - left - selfRect.width;
const deltaTop = top - selfRect.height - appBarOffset;
const spaceToTop = top - appBarOffset;
const deltaBottom = window.innerHeight - top - selfRect.height;
//console.log('self-width: ' + selfRect.width + ' | self-height: ' + selfRect.height);
//console.log('left: ' + deltaToLeft + ' | rigth:' + deltaToRight + ' | top: ' + deltaTop + ' | bottom: ' + deltaBottom + ' | spaceToTop: ' + spaceToTop);
let selector = popoverContentNode.mudPopoverFliped;
if (!selector) {
if (classList.contains('ent-popover-top-left')) {
if (deltaBottom < graceMargin && deltaToRight < graceMargin && spaceToTop >= selfRect.height && deltaToLeft >= selfRect.width) {
selector = 'top-and-left';
} else if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
selector = 'top';
} else if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
selector = 'left';
}
} else if (classList.contains('ent-popover-top-center')) {
if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
selector = 'top';
}
} else if (classList.contains('ent-popover-top-right')) {
if (deltaBottom < graceMargin && deltaToLeft < graceMargin && spaceToTop >= selfRect.height && deltaToRight >= selfRect.width) {
selector = 'top-and-right';
} else if (deltaBottom < graceMargin && spaceToTop >= selfRect.height) {
selector = 'top';
} else if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
selector = 'right';
}
}
else if (classList.contains('ent-popover-center-left')) {
if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
selector = 'left';
}
}
else if (classList.contains('ent-popover-center-right')) {
if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
selector = 'right';
}
}
else if (classList.contains('ent-popover-bottom-left')) {
if (deltaTop < graceMargin && deltaToRight < graceMargin && deltaBottom >= 0 && deltaToLeft >= selfRect.width) {
selector = 'bottom-and-left';
} else if (deltaTop < graceMargin && deltaBottom >= 0) {
selector = 'bottom';
} else if (deltaToRight < graceMargin && deltaToLeft >= selfRect.width) {
selector = 'left';
}
} else if (classList.contains('ent-popover-bottom-center')) {
if (deltaTop < graceMargin && deltaBottom >= 0) {
selector = 'bottom';
}
} else if (classList.contains('ent-popover-bottom-right')) {
if (deltaTop < graceMargin && deltaToLeft < graceMargin && deltaBottom >= 0 && deltaToRight >= selfRect.width) {
selector = 'bottom-and-right';
} else if (deltaTop < graceMargin && deltaBottom >= 0) {
selector = 'bottom';
} else if (deltaToLeft < graceMargin && deltaToRight >= selfRect.width) {
selector = 'right';
}
}
}
if (selector && selector != 'none') {
const newPosition = this.getPositionForFlippedPopver(classListArray, selector, boundingRect, selfRect);
left = newPosition.left;
top = newPosition.top;
offsetX = newPosition.offsetX;
offsetY = newPosition.offsetY;
popoverContentNode.setAttribute('data-mudpopover-flip', 'flipped');
}
else {
popoverContentNode.removeAttribute('data-mudpopover-flip');
}
if (classList.contains('ent-popover-overflow-flip-onopen')) {
if (!popoverContentNode.mudPopoverFliped) {
popoverContentNode.mudPopoverFliped = selector || 'none';
}
}
}
if (popoverContentNode.classList.contains('ent-popover-fixed')) {
} else if (window.getComputedStyle(popoverNode).position == 'fixed') {
popoverContentNode.style['position'] = 'fixed';
} else {
offsetX += window.scrollX;
offsetY += window.scrollY
}
popoverContentNode.style['left'] = (left + offsetX) + 'px';
popoverContentNode.style['top'] = (top + offsetY) + 'px';
if (window.getComputedStyle(popoverNode).getPropertyValue('z-index') != 'auto') {
popoverContentNode.style['z-index'] = window.getComputedStyle(popoverNode).getPropertyValue('z-index');
popoverContentNode.skipZIndex = true;
}
}
}
callback(id, mutationsList, observer) {
for (const mutation of mutationsList) {
if (mutation.type === 'attributes') {
const target = mutation.target
if (mutation.attributeName == 'class') {
if (target.classList.contains('ent-popover-overflow-flip-onopen') &&
target.classList.contains('ent-popover-open') == false) {
target.mudPopoverFliped = null;
target.removeAttribute('data-mudpopover-flip');
}
this.placePopoverByNode(target);
} else if (mutation.attributeName == 'data-ticks') {
const tickAttribute = target.getAttribute('data-ticks');
const parent = target.parentElement;
const tickValues = [];
let max = -1;
if (parent) {
for (let i = 0; i < parent.children.length; i++) {
const childNode = parent.children[i];
const tickValue = parseInt(childNode.getAttribute('data-ticks'));
if (tickValue == 0) {
continue;
}
if (tickValues.indexOf(tickValue) >= 0) {
continue;
}
tickValues.push(tickValue);
if (tickValue > max) {
max = tickValue;
}
}
}
if (tickValues.length == 0) {
continue;
}
const sortedTickValues = tickValues.sort((x, y) => x - y);
for (let i = 0; i < parent.children.length; i++) {
const childNode = parent.children[i];
const tickValue = parseInt(childNode.getAttribute('data-ticks'));
if (tickValue == 0) {
continue;
}
if (childNode.skipZIndex == true) {
continue;
}
childNode.style['z-index'] = 'calc(var(--ent-zindex-popover) + ' + (sortedTickValues.indexOf(tickValue) + 3).toString() + ')';
}
}
}
}
}
connect(id) {
console.log("connect PopOverComponent");
//this.initialize(this.mainContainerClass);
const popoverNode = document.getElementById('ent-popover-' + id);
const popoverContentNode = document.getElementById('ent-popover-content-' + id);
console.log(popoverNode)
console.log(popoverContentNode)
console.log(popoverNode.parentNode)
if (popoverNode && popoverNode.parentNode && popoverContentNode) {
this.placePopover(popoverNode);
const config = {attributeFilter: ['class', 'data-ticks']};
const observer = new MutationObserver(this.callback.bind(this, id));
observer.observe(popoverContentNode, config);
const resizeObserver = new ResizeObserver(entries => {
for (let entry of entries) {
const target = entry.target;
for (var i = 0; i < target.childNodes.length; i++) {
const childNode = target.childNodes[i];
if (childNode.id && childNode.id.startsWith('ent-popover-')) {
this.placePopover(childNode);
}
}
}
});
resizeObserver.observe(popoverNode.parentNode);
const contentNodeObserver = new ResizeObserver(entries => {
for (let entry of entries) {
var target = entry.target;
this.placePopoverByNode(target);
}
});
contentNodeObserver.observe(popoverContentNode);
this._map[id] = {
mutationObserver: observer,
resizeObserver: resizeObserver,
contentNodeObserver: contentNodeObserver
};
}
}
}
export function getPopoverComponent() {
return new PopOverComponent();
}
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
