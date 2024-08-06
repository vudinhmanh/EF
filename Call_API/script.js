const studentsApiUrl = "https://localhost:7091/api/Students";
const professorsApiUrl = "https://localhost:7091/api/Professors";
document.addEventListener("DOMContentLoaded", getAllProfessors);
document.addEventListener("DOMContentLoaded", getAllStudents);
//Lấy sinh viên
async function getAllStudents() {
  try {
    const response = await fetch(studentsApiUrl);
    const students = await response.json();
    const tableBody = document.getElementById("allStudent");
    tableBody.innerHTML = "";

    students.forEach((student) => {
      const row = document.createElement("tr");
      row.innerHTML = `
                <td>${student.id}</td>
                <td>${student.name}</td>
                <td>${student.phone}</td>
                <td>${student.email}</td>
                <td>${student.personRole}</td>
                <td>${student.gpa}</td>
                <td>
                <button onclick="openStudentEditForm('${student.id}')">Sửa</button>
                <button onclick="deleteStudent('${student.id}')">Xoá</button>
                </td>
            `;
      tableBody.appendChild(row);
    });
  } catch (error) {
    console.error("Error fetching students:", error);
  }
}
// Thêm sinh viên
document
  .getElementById("addStudentForm")
  .addEventListener("submit", async function (event) {
    event.preventDefault();
    const form = event.target;
    const formData = new FormData(form);
    const student = {
      name: formData.get("name"),
      phone: formData.get("phone"),
      email: formData.get("email"),
      gpa: parseFloat(formData.get("gpa")),
    };
    try {
      const response = await fetch(studentsApiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(student),
      });

      if (!response.ok) {
        throw new Error("Thất bại");
      } else {
        alert("Thêm thành công");
      }
      getAllStudents();
    } catch (error) {
      console.error("Error", error);
      alert("Error");
    }
  });
//Xoá sinh viên
async function deleteStudent(id) {
  if (!confirm("Bạn có muốn xoá không?")) {
    return;
  }
  try {
    const response = await fetch(`${studentsApiUrl}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error(`Failed to delete student with ID ${id}`);
    }
    getAllStudents();
  } catch (error) {
    console.error("Error deleting student:", error);
  }
}
//Sửa sinh viên
async function openStudentEditForm(id) {
  try {
    const response = await fetch(`${studentsApiUrl}/${id}`);
    if (!response.ok) {
      throw new Error("Error fetching professor data");
    }
    const student = await response.json();
    
    // Điền thông tin vào form
    document.getElementById("idStudent").value = student.id;
    document.getElementById("nameStudent").value = student.name;
    document.getElementById("phoneStudent").value = student.phone;
    document.getElementById("emailStudent").value = student.email;
    document.getElementById("gpaStudent").value = student.gpa;
    
    // Hiển thị form sửa
    document.getElementById("fromStudentEdit").style.display = "block";
  } catch (error) {
    console.error("Error:", error);
  }
}
document
  .getElementById("fromStudentEdit")
  .addEventListener("submit", async function (event) {
    event.preventDefault();
    const form = event.target;
    const formData = new FormData(form);
    const student = {
      id: formData.get("idStudent"),
      name: formData.get("nameStudent"),
      phone: formData.get("phoneStudent"),
      email: formData.get("emailStudent"),
      gpa: parseFloat(formData.get("gpaStudent")),
    };
    try {
      const response = await fetch(`${studentsApiUrl}/${student.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(student),
      });

      if (!response.ok) {
        throw new Error("Có lỗi khi sửa");
      } else {
        alert("Sửa thành công");
      }
      getAllStudents();
      closeForm("fromStudentEdit");
    } catch (error) {
      console.error("Error:", error);
      alert("Error");
    }
  });

//Lấy giảng  viên
async function getAllProfessors(filteredData = null) {
  try {
    const response = await fetch(professorsApiUrl);
    const professors = await response.json();
    const tableBody = document.getElementById("allProfessor");
    tableBody.innerHTML = "";
    professors.forEach((professor) => {
      const row = document.createElement("tr");
      row.innerHTML = `
                <td>${professor.id}</td>
                <td>${professor.name}</td>
                <td>${professor.phone}</td>
                <td>${professor.email}</td>
                <td>${professor.personRole}</td>
                <td>${professor.salary}</td>
                <td>
                <button onclick="openProfessorEditForm('${professor.id}')">Sửa</button>
                <button onclick="deleteProfessor('${professor.id}')">Xoá</button>
                </td>
            `;
      tableBody.appendChild(row);
    });
  } catch (error) {
    console.error("Error fetching students:", error);
  }
}

// Thêm giảng viên
document
  .getElementById("addProfessorForm")
  .addEventListener("submit", async function (event) {
    event.preventDefault();
    const form = event.target;
    const formData = new FormData(form);
    const professor = {
      name: formData.get("name"),
      phone: formData.get("phone"),
      email: formData.get("email"),
      salary: parseFloat(formData.get("salary")),
    };
    try {
      const response = await fetch(professorsApiUrl, {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(professor),
      });

      if (!response.ok) {
        throw new Error("Thất bại");
      } else {
        alert("Thêm thành công");
      }
      getAllProfessors();
    } catch (error) {
      console.error("Error", error);
      alert("Error");
    }
  });
//Xoá giảng viên
async function deleteProfessor(id) {
  if (!confirm("Bạn có muốn xoá không?")) {
    return;
  }
  try {
    const response = await fetch(`${professorsApiUrl}/${id}`, {
      method: "DELETE",
    });
    if (!response.ok) {
      throw new Error(`Failed to delete student with ID ${id}`);
    }
    getAllProfessors();
  } catch (error) {
    console.error("Error deleting student:", error);
  }
}
//Sửa giảng viên
async function openProfessorEditForm(id) {
  try {
    const response = await fetch(`${professorsApiUrl}/${id}`);
    if (!response.ok) {
      throw new Error("Error fetching professor data");
    }
    const professor = await response.json();
    
    // Điền thông tin vào form
    document.getElementById("idProfessor").value = professor.id;
    document.getElementById("nameProfessor").value = professor.name;
    document.getElementById("phoneProfessor").value = professor.phone;
    document.getElementById("emailProfessor").value = professor.email;
    document.getElementById("salaryProfessor").value = professor.salary;
    
    // Hiển thị form sửa
    document.getElementById("fromProfessorEdit").style.display = "block";
  } catch (error) {
    console.error("Error opening edit form:", error);
  }
}

// Cập nhật thông tin giảng viên
document
  .getElementById("fromProfessorEdit")
  .addEventListener("submit", async function (event) {
    event.preventDefault();
    const form = event.target;
    const formData = new FormData(form);
    const professor = {
      id: formData.get("idProfessor"),
      name: formData.get("nameProfessor"),
      phone: formData.get("phoneProfessor"),
      email: formData.get("emailProfessor"),
      salary: parseFloat(formData.get("salaryProfessor")),
    };
    try {
      const response = await fetch(`${professorsApiUrl}/${professor.id}`, {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(professor),
      });

      if (!response.ok) {
        throw new Error("Có lỗi khi sửa");
      } else {
        alert("Sửa thành công");
      }
      getAllProfessors();  // Tải lại danh sách giảng viên sau khi sửa
      closeForm("fromProfessorEdit");  // Đóng popup
    } catch (error) {
      console.error("Error:", error);
      alert("Error");
    }
  });

// Xác định giảng viên hay sinh viên để tìm cho đúng
function search() {
  const searchText = document.getElementById("searchInput").value.toLowerCase();
  const selectedOption = document.querySelector('input[name="viewOption"]:checked').value;
  if (selectedOption === 'students') {
    searchStudents(searchText);
  } else if (selectedOption === 'leaders') {
    searchProfessors(searchText);
  }
}
//tìm kiếm sinh viên
async function searchStudents(searchText) {
  try {
    const response = await fetch(studentsApiUrl);
    const students = await response.json();
    const filteredStudents = students.filter(student => 
      student.name.toLowerCase().includes(searchText) ||
      student.phone.toLowerCase().includes(searchText) ||
      student.email.toLowerCase().includes(searchText)
    );
    const tableBody = document.getElementById("allStudent");
    tableBody.innerHTML = "";
    filteredStudents.forEach((student) => {
      const row = document.createElement("tr");
      row.innerHTML = `
        <td>${student.id}</td>
        <td>${student.name}</td>
        <td>${student.phone}</td>
        <td>${student.email}</td>
        <td>${student.personRole}</td>
        <td>${student.gpa}</td>
        <td>
          <button onclick="openStudentEditForm('${student.id}')">Sửa</button>
          <button onclick="deleteStudent('${student.id}')">Xoá</button>
        </td>
      `;
      tableBody.appendChild(row);
    });
  } catch (error) {
    console.error("Error:", error);
  }
}
//tìm kiếm giảng viên
async function searchProfessors(searchText) {
  try {
    const response = await fetch(professorsApiUrl);
    const professors = await response.json();
    const filteredProfessors = professors.filter(professor => 
      professor.name.toLowerCase().includes(searchText) ||
      professor.phone.toLowerCase().includes(searchText) ||
      professor.email.toLowerCase().includes(searchText)
    );
    const tableBody = document.getElementById("allProfessor");
    tableBody.innerHTML = "";
    filteredProfessors.forEach((professor) => {
      const row = document.createElement("tr");
      row.innerHTML = `
        <td>${professor.id}</td>
        <td>${professor.name}</td>
        <td>${professor.phone}</td>
        <td>${professor.email}</td>
        <td>${professor.personRole}</td>
        <td>${professor.salary}</td>
        <td>
          <button onclick="openProfessorEditForm('${professor.id}')">Sửa</button>
          <button onclick="deleteProfessor('${professor.id}')">Xoá</button>
        </td>
      `;
      tableBody.appendChild(row);
    });
  } catch (error) {
    console.error("Error:", error);
  }
}