// Form Wizard

$(document).ready(() => {
  setTimeout(function () {
    $("#smartwizard3").smartWizard({
      selected: 0,
      transitionEffect: "fade",
      toolbarSettings: {
        toolbarPosition: "none",
      },
      anchorSettings: {
        enableAllAnchors: true, // Activates all anchors clickable all times
    },
    });

    // External Button Events
    $("#reset-btn22").on("click", function () {
      // Reset wizard
      $("#smartwizard3").smartWizard("reset");
      return true;
    });

    $("#prev-btn22").on("click", function () {
      // Navigate previous
      $("#smartwizard3").smartWizard("prev");
      return true;
    });

    $("#next-btn22").on("click", function () {
      // Navigate next
      $("#smartwizard3").smartWizard("next");
      return true;
    });
  }, 2000);
});
