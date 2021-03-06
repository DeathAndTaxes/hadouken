angular.module('hadouken.dashboard.widgets.pluginList', [
    'hadouken.jsonrpc',
    'hadouken.messaging'
])
.controller('Widgets.PluginListController', function($scope, jsonrpc) {
    jsonrpc.request('core.plugins.list', {
        success: function(data) {
            $scope.plugins = data.result;
        }
    });

    $scope.$on('$destroy', function() {
        console.log('scope dstroyed.');
    });
})
.run(['messageService', 'jsonrpc', function(messageService, jsonrpc) {
    messageService.subscribe('hadouken.dashboard.onloaded', function() {
        var widget = {
            id: 'a896e1cb-eb5d-4aa3-99cf-b406c1debb47',
            title: 'Plugin list',
            hasConfiguration: true,
            size: 'small',
            templateUrl: 'views/dashboard/widgets/pluginList.html'
        };

        messageService.publish('hadouken.dashboard.widgets.add', widget);
    });
}]);
