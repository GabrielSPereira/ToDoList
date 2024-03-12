function cadastrar() {
    // Inicia a massa de dados (payload)
    let payload = {
        name: document.querySelector("#fullName").value,
        email: document.querySelector("#email").value,
        password: document.querySelector("#password").value
    }

    // Enviar para API
    fetch("https://localhost:7173/api/users", {
            method: 'POST',
            mode: 'cors',
            credentials: 'include',
            body: JSON.stringify(payload),
            headers: {
                'Content-Type': 'application/json'
            }
        })
        .then(response => response.json())
        .then(response => {
            Swal.fire({
                title: 'Bom Trabalho!',
                text: "Cadastrado com sucesso!",
                icon: 'success',
                confirmButtonText: 'Ok!'
            }).then((result) => {
                if (result.isConfirmed) {
                    localStorage.setItem("userName", response.fullName);
                    localStorage.setItem("idClient", response.id);

                    window.location.href = "list.html";
                }
            })
        })
}