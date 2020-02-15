node {
    def app

    stage('Clone') {
        checkout scm
    }

    stage('Build') {
        app = docker.build("sk8m8/testing-repo")
    }

    stage('Push') {
        docker.withRegistry('https://registry.hub.docker.com', 'docker-hub-credentials') {
            app.push("${env.BUILD_NUMBER}")
            app.push("latest")
        }
    }
}