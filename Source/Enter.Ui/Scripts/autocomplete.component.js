export class AutoCompleteComponent {

    initialize(dotNetRef, inputElement) {
        inputElement.onkeyup  = function (){
            dotNetRef.invokeMethodAsync('OnInputChange',inputElement.value);
        }
    }
}

export function getAutoCompleteComponent() {
    return new AutoCompleteComponent();
}