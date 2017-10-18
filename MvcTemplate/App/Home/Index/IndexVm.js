import less from './Index.less'
import ApiService from 'Shared/ApiService.js'

export default class {

    constructor() {

    }

    click() {

        ApiService.get()
            .then(data => {
                
                var ul = document.getElementById("list");

                for(var i = 0; i < data.length; i++) {
                    var li = document.createElement("li");
                    li.appendChild(document.createTextNode(data[i]));
                    ul.appendChild(li);
                }

                console.log('here');
            });

    }

}