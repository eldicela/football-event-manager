﻿const changeStatusModal = document.getElementById('changeStatusModal')
const modalSubmmitBtn = document.getElementById("changeStatModalSubmmitBtn");
const changeStatusForm = document.getElementById("changeStatusModalForm");
const modalCloseBtn = document.getElementById("modal-close-btn");

let matchId = 0;

const updateMatchId = (newId) => {
    matchId = newId;
}

changeStatusModal.addEventListener('show.bs.modal', function (event) {
    // Button that triggered the modal
    const changeStatusModalBtn = event.relatedTarget
    console.log(changeStatusModalBtn)
    // Extract info from data-bs-* attributes
    const id = changeStatusModalBtn.getAttribute('data-bs-matchId')
    console.log(id)
    updateMatchId(id)
})

const changeStatusFormSubmitHandler = async (event) => {
    event.preventDefault();
    const statusStringHtmlEl = document.getElementById(`match-status-string-${matchId}`);
    console.log(statusStringHtmlEl);

    const newStatus = event.target["match-stat-change"].value;

    const body = {
        Id: matchId,
        Status: newStatus,
    }

    console.log(body)
    console.log(JSON.stringify(body))

    const response = await fetch(`${BASE_APP_PATH}/admin/matches/UpdateStatus`, {
        method: "POST",
        body: JSON.stringify(body),
        headers: { "Content-Type": "application/json", }
    })

    if (!response.ok) {
        console.log("response is not ok")
        return
    }

    console.log("response is ok")

    var data = await response.json()
    console.log(data);
    statusStringHtmlEl.innerText = newStatus.toString();
    modalCloseBtn.click();

}


changeStatusForm.addEventListener("submit", changeStatusFormSubmitHandler);