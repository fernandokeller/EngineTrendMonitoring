//#region On Document Load
window.addEventListener("DOMContentLoaded", () => {
    LoadTailVolumeChart();
});
//#endregion

//#region Load Tail Volume Chart
function LoadTailVolumeChart() {
    const element = document.querySelector("#tailVolumeChart");
    const chart = new Chart(element, {
        type: "line",
        data: {
            labels: [
                "06/16/2024",
                "06/17/2024",
                "06/18/2024",
                "06/19/2024",
                "06/20/2024",
                "06/21/2024",
                "06/22/2024"
            ],
            datasets: [{
                data: [
                    1500,
                    1300,
                    1100,
                    900,
                    700,
                    500,
                    1500
                ],
                lineTension: 0,
                backgroundColor: "transparent",
                borderColor: "#007bff",
                borderWidth: 4,
                pointBackgroundColor: "#007bff"
            }]
        },
        options: {
            plugins: {
                legend: {
                    display: false
                },
                tooltip: {
                    boxPadding: 3
                }
            }
        }
    });
}
//#endregion

//#region Load Flight Hours And Cycles Chart
function LoadFlightHoursAndCyclesChart() {

}
//#endregion

//#region Load Outside Info Chart
function LoadOutsideInfoChart() {

}
//#endregion
