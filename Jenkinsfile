node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/testing-repo")
    }

    stage('Push') {
        app.push("latest")
    }
}