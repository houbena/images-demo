pipeline {

    agent any

    stages {
        stage('Build') {
            steps {
                sh 'docker image build -t myapp:build-${BUILD_ID} .'
                sh 'docker image build --target testrunner -t myapp:testbuild-${BUILD_ID} .'
            }
        }
        stage('Test') {
            steps {
                sh 'docker container run myapp:test-${BUILD_ID}'
            }
        }
        stage('Deploy') {
            steps {
                sh 'docker container run myapp:1.0-${BUILD_ID}'
            }
        }
    }
}
