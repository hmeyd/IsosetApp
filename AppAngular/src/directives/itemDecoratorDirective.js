'use strict';
app.directive('decorateItem', function () {
    return {
        template: 'Item "{{item.name}}" dans la categorie { { item.category_id } }'
    });