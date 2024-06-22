(() => {
    "use strict"

    //#region On Document Load
    window.addEventListener("DOMContentLoaded", () => {
        BindThemeButton();

        UseTheme(GetTheme());
    });
    //#endregion

    //#region Save Theme
    function SaveTheme(theme) {
        localStorage.setItem("theme", theme);
    }
    //#endregion

    //#region Get Theme
    function GetTheme() {
        const theme = localStorage.getItem("theme");

        if (!theme) {
            return window.matchMedia("(prefers-color-scheme: dark)").matches ? "dark" : "light";
        }

        return theme;
    }
    //#endregion

    //#region Use Theme
    function UseTheme(theme) {
        if (!theme) {
            return;
        }

        SaveTheme(theme);
        document.documentElement.setAttribute("data-bs-theme", theme);

        const themeButtons = document.querySelectorAll("button[data-bs-theme-value]");
        const selectedThemeButton = document.querySelector(`button[data-bs-theme-value="${theme}"]`);

        if (themeButtons.length == 0) {
            return;
        }

        for (let item of themeButtons) {
            item.classList.remove("active");
        }

        if (selectedThemeButton) {
            selectedThemeButton.classList.add("active");
        }
    }
    //#endregion

    //#region Bind Theme Button
    function BindThemeButton() {
        const buttons = document.querySelectorAll("button[data-bs-theme-value]");

        if (buttons.length == 0) {
            return;
        }

        for (let button of buttons) {
            button.removeEventListener("click", OnClickThemeButton);
            button.addEventListener("click", OnClickThemeButton);
        }
    }
    //#endregion

    //#region OnClickThemeButton
    function OnClickThemeButton(e) {
        const theme = e.target.dataset.bsThemeValue;

        UseTheme(theme);
    }
    //#endregion
})()